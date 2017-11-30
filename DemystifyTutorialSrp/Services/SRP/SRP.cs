// srp4net 1.0
// SRP for .NET - A JavaScript/C# .NET library for implementing the SRP authentication protocol
// http://code.google.com/p/srp4net/
// Copyright 2010, Sorin Ostafiev (http://www.ostafiev.com/)
// License: GPL v3 (http://www.gnu.org/licenses/gpl-3.0.txt)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace srp4net.Helpers
{
    public abstract partial class Crypto
    {
        public abstract class SRP
        {
            public static BigInteger N { get; private set; }
            public static string NHex { get; private set; }
            public static int _nbits;
            private static BigInteger Nminus1;

            public static BigInteger g { get; private set; }
            public static string gHex { get; private set; }

            public static BigInteger k { get; private set; }
            public static string kHex { get; private set; }

            private static string HHex(string x)
            {
                return Crypto.HashHex((((x.Length & 1) == 0) ? "" : "0") + x);
            }

            static SRP()
            {
                // initialize N
                {
                    NHex =
                        //512bit
                        "D4C7F8A2B32C11B8FBA9581EC4BA4F1B04215642EF7355E37C0FC0443EF756EA2C6B8EEB755A1C723027663CAA265EF785B8FF6A9B35227A52D86633DBDFCA43";

                    N = new BigInteger(NHex, 16);
                    _nbits = N.bitCount();
                    Nminus1 = N - 1;

                    if (!N.isProbablePrime(80))
                    {
                        throw new Exception("Warning: N is not prime");
                    }

                    if (!(Nminus1 / 2).isProbablePrime(80))
                    {
                        throw new Exception("Warning: (N-1)/2 is not prime");
                    }
                }

                // initialize g
                {
                    gHex = "2";
                    g = new BigInteger(gHex, 16);
                }

                // initialize k = H(N || g)
                {
                    BigInteger ktmp = new BigInteger(HHex(
                        (((NHex.Length & 1) == 0) ? "" : "0") + NHex +
                        new string('0', NHex.Length - gHex.Length) + gHex
                        ), 16);

                    k = (ktmp < N) ? ktmp : (ktmp % N);
                    kHex = k.ToHexString();
                }
            }

            public static void AuthStep1(
                string vHex,
                string AHex,
                out string bHex,
                out string BHex,
                out string uHex)
            {
                BigInteger v = new BigInteger(vHex, 16);
                BigInteger A = new BigInteger(AHex, 16);

                BigInteger b;
                // b - ephemeral private key
                // b = random between 2 and N-1
                {
                    b = new BigInteger();
                    //[TODO] perhaps here use a better random generator
                    b.genRandomBits(_nbits, new Random((int)DateTime.Now.Ticks));

                    if (b >= N)
                    {
                        b = b % Nminus1;
                    }
                    if (b < 2)
                    {
                        b = 2;
                    }
                }
                bHex = b.ToHexString();

                // B = public key
                // B = kv + g^b (mod N)
                BigInteger B = (v * k + g.modPow(b, N)) % N;
                BHex = B.ToHexString();

                BigInteger u;
                // u - scrambling parameter
                // u = H (A || B)
                {
                    int nlen = 2 * ((_nbits + 7) >> 3);

                    BigInteger utmp = new BigInteger(HHex(
                        new string('0', nlen - AHex.Length) + AHex +
                        new string('0', nlen - BHex.Length) + BHex
                        ), 16);

                    u = (utmp < N) ? utmp : (utmp % Nminus1);
                }

                uHex = u.ToHexString();
            }

            public static void AuthStep2(
                string vHex,
                string uHex,
                string AHex,
                string bHex,
                string BHex,
                out string m1serverHex,
                out string m2Hex)
            {
                BigInteger v = new BigInteger(vHex, 16);
                BigInteger u = new BigInteger(uHex, 16);
                BigInteger A = new BigInteger(AHex, 16);
                BigInteger b = new BigInteger(bHex, 16);
                BigInteger B = new BigInteger(BHex, 16);

                // S - common exponential value
                // S = (A * v^u) ^ b (mod N)
                BigInteger S = ((v.modPow(u, N) * A) % N).modPow(b, N);

                // K - the strong cryptographically session key
                // K = H(S)
                string KHex = HHex(S.ToHexString()).TrimStart('0');

                // m2 - expected client's proof as computed by the server
                m1serverHex = HHex(
                    AHex +
                    BHex +
                    KHex).TrimStart('0');

                // m2 - server's proof that it has the correct key
                m2Hex = HHex(
                    AHex +
                    m1serverHex +
                    KHex).TrimStart('0');
            }
        }
    }
}

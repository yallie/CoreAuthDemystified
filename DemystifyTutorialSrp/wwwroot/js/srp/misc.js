﻿// srp4net 1.0
// SRP for .NET - A JavaScript/C# .NET library for implementing the SRP authentication protocol
// http://code.google.com/p/srp4net/
// Copyright 2010, Sorin Ostafiev (http://www.ostafiev.com/)
// License: GPL v3 (http://www.gnu.org/licenses/gpl-3.0.txt)

(function($)
{
    $.extend({
        toJSON: function(object)
        {
            return JSON.stringify(object);
        }
    });
})(jQuery);



function compareTo(big1, big2)
{
    // -1 if big1 < big2
    //  1 if big1 > big2
    //  0 if equal
    if (greater(big1, big2))
    {
        return 1;
    }
    else
    {
        if (equals(big1, big2))
        {
            return 0;
        }
    }
    return -1;
}

function WS(fnServer, data, fnSuccess)
{
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        async: false,
        url: "ws.asmx/" + fnServer,
        data: $.toJSON(data),
        dataType: "json",

        success: function(msg)
        {
            fnSuccess(msg.d);
        },

        error: function(xhr, msg, error)
        {
            var err = eval("(" + xhr.responseText + ")");
            $.log(err.Message + "\n" + err.StackTrace);
        }
    })
}

function PostData(localUrl, data, token, complete) {
    return $.ajax({
        type: "POST", // "GET" works, "POST" doesn't
        contentType: "application/json; charset=utf-8",
        url: localUrl,
        data: $.toJSON(data),
        dataType: "json",
        headers: { 'RequestVerificationToken': token },

        success: function (data, status, xhr) {
            complete(data);
        }

        /*,

        complete: function (xhr, msg) {
            alert(msg);
            //complete(msg);
        },

        success: function () { // (data, status, xhr) {
            document.write("PostData executed.");
            ////alert('PostData!');
            ////console.log('Data received: ');
            ////console.log(data);
            ////fnSuccess(data);
        },

        error: function(xhr, msg, error) {
            //var err = eval("(" + xhr.responseText + ")");
            //$.log(err.Message + "\n" + err.StackTrace);
            $.log(msg);
            $.log(error);
        }*/
    });
}

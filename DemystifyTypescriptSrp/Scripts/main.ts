// document.getElementById("helloworld").innerText = "Hello world from the TypeScript";

// doesn't work in TypeScript:
// var $ = require('jquery');
// $("#helloworld").text("Hello world");

import $ from "jquery";

$("#helloworld").text("Hello world from the TypeScript and JQuery");

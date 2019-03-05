"use strict";
exports.__esModule = true;
var Tokenizer = /** @class */ (function () {
    function Tokenizer(input) {
        if (input != null && input !== "") {
            this.input = input;
        }
        else {
            this.input = "";
        }
    }
    Tokenizer.prototype.tokenize = function () {
        var tokens = this.input.split(" ");
        var ret = [];
        for (var i = 0; i < tokens.length; i++) {
            if (tokens[i].includes(",")) {
                var splitted = tokens[i].split(",");
                for (var j = 0; j < splitted.length; j++) {
                    ret.push(splitted[j]);
                }
            }
            else {
                ret.push(tokens[i]);
            }
        }
        console.log("tokens: " + ret);
        return ret;
    };
    return Tokenizer;
}());
exports.Tokenizer = Tokenizer;

"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class Tokenizer {
    constructor(input) {
        if (input != null && input !== "") {
            this.input = input;
        }
        else {
            this.input = "";
        }
    }
    tokenize() {
        let tokens = this.input.split(" ");
        let ret = [];
        for (let i = 0; i < tokens.length; i++) {
            if (tokens[i].includes(",")) {
                let splitted = tokens[i].split(",");
                for (let j = 0; j < splitted.length; j++) {
                    ret.push(splitted[j]);
                }
            }
            else {
                ret.push(tokens[i]);
            }
        }
        console.log("tokens: " + ret);
        return ret;
    }
}
exports.Tokenizer = Tokenizer;

"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const States_1 = require("./States");
class SQLParser {
    constructor(tokens, attrs) {
        if (tokens != null && tokens.length > 0) {
            this.tokens = tokens;
        }
        else {
            console.error("parser error: empty token");
        }
        if (attrs != null) {
            this.attr = attrs;
        }
        else {
            console.log("parser error: attributes undefined");
        }
        this.states = new Array();
        this.states[0] = States_1.startState;
        this.states[1] = States_1.state1;
        this.states[2] = States_1.state2;
        this.states[3] = States_1.state3;
        this.states[4] = States_1.state4;
        this.states[5] = States_1.state5;
        this.states[6] = States_1.state6;
        this.states[7] = States_1.state7;
        this.states[8] = States_1.endState;
        this.states[9] = States_1.errorState;
        this.state = this.states[0];
    }
    parse() {
        for (let i = 0; i < this.tokens.length; i++) {
            console.log("parsing " + this.tokens[i]);
            this.state.parse(this, this.tokens[i], this.attr);
        }
    }
    changeState(stateIndex) {
        this.state = this.states[stateIndex];
        console.log("new state" + stateIndex);
    }
    reset() {
        this.tokens = null;
        this.state = this.states[0];
    }
}
exports.SQLParser = SQLParser;

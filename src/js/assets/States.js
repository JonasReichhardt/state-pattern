"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class StartState {
    parse(context, token, attr) {
        switch (token) {
            case "SELECT":
                context.changeState(1);
                break;
            default:
                context.changeState(9);
        }
    }
}
class State1 {
    parse(context, token, attr) {
        console.log("Attribute length:" + attr.length);
        if (attr.indexOf(token) !== -1) {
            attr.splice(attr.indexOf(token), 1);
            context.changeState(2);
        }
        else {
            context.changeState(9);
        }
        console.log("new Attribute length:" + attr.length);
    }
}
class State2 {
    parse(context, token, attr) {
        if (attr.indexOf(token) !== -1) {
            attr.splice(attr.indexOf(token), 1);
            context.changeState(2);
        }
        else if (token === "FROM") {
            context.changeState(3);
        }
        else {
            context.changeState(9);
        }
    }
}
class State3 {
    parse(context, token, attr) {
        if (token === "user" + ";") {
            context.changeState(8);
        }
        else if (token === "user") {
            context.changeState(4);
        }
        else {
            context.changeState(9);
        }
    }
}
class State4 {
    parse(context, token, attr) {
        if (token === "WHERE") {
            context.changeState(5);
        }
        else {
            context.changeState(9);
        }
    }
}
class State5 {
    parse(context, token, attr) {
        console.log("State5");
    }
}
class State6 {
    parse(context, token, attr) {
        console.log("State6");
    }
}
class State7 {
    parse(context, token, attr) {
        console.log("State6");
    }
}
class EndState {
    parse(context, token, attr) {
        console.log("EndState");
    }
}
class ErrorState {
    parse(context, token, attr) {
        console.log("ErrorState");
    }
}
exports.startState = new StartState();
exports.state1 = new State1();
exports.state2 = new State2();
exports.state3 = new State3();
exports.state4 = new State4();
exports.state5 = new State5();
exports.state6 = new State6();
exports.state7 = new State7();
exports.endState = new EndState();
exports.errorState = new ErrorState();

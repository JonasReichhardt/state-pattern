import { SQLParser } from "./Parser";

export interface IState {
	parse(context: SQLParser, token: string, attr: Array<string>): void;
}

class StartState implements IState {
	parse(context: SQLParser, token: string, attr: Array<string>): void {
		switch (token) {
			case "SELECT":
				context.changeState(1);
				break;
			default:
				context.changeState(9);
		}
	}
}

class State1 implements IState {
	parse(context: SQLParser, token: string, attr: string[]): void {
		console.log("Attribute length:" + attr.length);
		if (attr.indexOf(token) !== -1) {
			attr.splice(attr.indexOf(token), 1);
			context.changeState(2);
		} else {
			context.changeState(9);
		}
		console.log("new Attribute length:" + attr.length);
	}
}

class State2 implements IState {
	parse(context: SQLParser, token: string, attr: Array<string>): void {
		if (attr.indexOf(token) !== -1) {
			attr.splice(attr.indexOf(token), 1);
			context.changeState(2);
		} else if (token === "FROM") {
			context.changeState(3);
		} else {
			context.changeState(9);
		}
	}
}

class State3 implements IState {
	parse(context: SQLParser, token: string, attr: Array<string>): void {
		if (token === "user" + ";") {
			context.changeState(8);
		} else if (token === "user") {
			context.changeState(4);
		} else {
			context.changeState(9);
		}
	}
}

class State4 implements IState {
	parse(context: SQLParser, token: string, attr: Array<string>): void {
		if (token === "WHERE") {
			context.changeState(5);
		} else {
			context.changeState(9);
		}
	}
}

class State5 implements IState {
	parse(context: SQLParser, token: string, attr: Array<string>): void {
		console.log("State5");
	}
}

class State6 implements IState {
	parse(context: SQLParser, token: string, attr: Array<string>): void {
		console.log("State6");
	}
}

class State7 implements IState {
	parse(context: SQLParser, token: string, attr: Array<string>): void {
		console.log("State6");
	}
}

class EndState implements IState {
	parse(context: SQLParser, token: string, attr: Array<string>): void {
		console.log("EndState");
	}
}

class ErrorState implements IState {
	parse(context: SQLParser, token: string, attr: Array<string>): void {
		console.log("ErrorState");
	}
}

export const startState: StartState = new StartState();
export const state1: State1 = new State1();
export const state2: State2 = new State2();
export const state3: State3 = new State3();
export const state4: State4 = new State4();
export const state5: State5 = new State5();
export const state6: State6 = new State6();
export const state7: State7 = new State7();
export const endState: EndState = new EndState();
export const errorState: ErrorState = new ErrorState();


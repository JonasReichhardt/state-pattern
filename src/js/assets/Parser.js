import { StartState, State1, State2, EndState, ErrorState} from "./States.js";

export class SQLParser{

	constructor(tokens){
		if(tokens != null && tokens != ""){
			this.tokens = tokens;
		}else{
			console.error("parser error: empty token");
		}

		this.states = [];
		this.states[0] = new StartState();
		this.states[1] = new State1();
		this.states[2] = new State2();
		this.states[3] = new EndState();
		this.states[4] = new ErrorState();

		this.state = this.states[0];
	}

	parse(tokens){
		if(tokens != null && tokens != ""){
			this.tokens = tokens;
		}
		console.log("parsing "+this.tokens+"...")
	}

	reset(){
		this.tokens = null;
		this.state = this.states[0];
	}
}
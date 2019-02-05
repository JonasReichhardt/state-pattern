export class Tokenizer {

	constructor(input, attr){
		if(input != null && input != ""){
			this.input = input;
		}
	}

	tokenize(input) {
		if (input != "" && input != null) {
			this.input = input;	
		}
		console.log("tokenize "+this.input+"...");
		return this.input.split(" ");
	}
}
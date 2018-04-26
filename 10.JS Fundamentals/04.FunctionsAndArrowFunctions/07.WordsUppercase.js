function toUpperCaseFunc(input){
    let result = input
                    .toUpperCase()
                    .split(/\W+/)
                    .filter(w => w !== '')
                    .join(', ');
                    
    console.log(result);
}

toUpperCaseFunc('Hi, how are you?');
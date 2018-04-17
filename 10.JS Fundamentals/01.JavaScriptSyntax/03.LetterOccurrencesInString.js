function letterCount(word, letter){
    let count = 0;

    for(let i of word){
        if(i === letter){
            count++;
        }
    }

    console.log(count);
}

letterCount('hello', 'l')
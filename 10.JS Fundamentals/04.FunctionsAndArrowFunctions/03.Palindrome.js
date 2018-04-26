function palindrome(input){
    let reverseInput = input.split('').reverse().join('')
    
    return input === reverseInput ? true : false;
}

console.log(palindrome('valio'));
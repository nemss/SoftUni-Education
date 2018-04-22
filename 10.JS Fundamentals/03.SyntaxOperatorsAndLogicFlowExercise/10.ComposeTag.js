function composeTag(data){
    let fileLocation = data[0];
    let alternateText = data[1];

    let output = `<img src="${fileLocation}" alt="${alternateText}">`
    console.log(output);
}

composeTag(['smiley.gif', 'Smiley Face'])
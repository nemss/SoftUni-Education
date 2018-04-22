function nowPlaying(data){
    let artistName = data[1];
    let trackName = data[0];
    let duration = data[2];

    console.log(`Now Playing: ${artistName} - ${trackName} [${duration}]`);
}

nowPlaying(['Number One', 'Nelly', '4:09']);
function createSong(input) {
    class Song {
        constructor(typeList, name, time) {
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    const songsCount = input.shift();
    const typeSong = input.pop();
    let songs = [];

    for (let i = 0; i < songsCount; i++) {
        let currSongInfo = input[i];
        let [typeList, name, time] = currSongInfo.split("_");
        let song = new Song(typeList, name, time);
        songs.push(song);
    }

    if (typeSong === "all"){
        songs.forEach((s) => console.log(s.name));
     }else {
        let filtered = songs.filter((s) => s.typeList === typeSong);
        filtered.forEach((s) => console.log(s.name));
     }
}

createSong([2,
    'like_Replay_3:15',
    'ban_Photoshop_3:48',
    'all']
    );

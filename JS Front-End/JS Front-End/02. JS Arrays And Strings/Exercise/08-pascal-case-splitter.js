function splitText (text) {
    let regex = /[A-Z][a-z]*/g;
    let matches = text.match(regex);
    console.log(matches.join(", "));
}

splitText('SplitMeIfYouCanHaHaYouCantOrYouCan')
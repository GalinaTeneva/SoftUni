function encodeAndDecodeMessages() {
    let textBoxes = document.getElementsByTagName("textarea");
    let encodeTextBox = textBoxes[0];
    let decodeTextBox = textBoxes[1];

    let buttons = document.getElementsByTagName("button");
    let encodeButton = buttons[0];
    let decodeButton = buttons[1];

    encodeButton.addEventListener("click", encode);
    decodeButton.addEventListener("click", decode);

    function encode(){
        let messageToEncode = encodeTextBox.value;
        let newMessage = "";

        for(let i = 0; i < messageToEncode.length; i++){
            let newText = String.fromCodePoint(messageToEncode[i].charCodeAt(0)+1);
            newMessage += newText;
        }

        decodeTextBox.value = newMessage;
        encodeTextBox.value = "";
        decodeButton.disabled = false;
    }
    function decode(e){
        let messageToDecode = decodeTextBox.value;
        let newMessage = "";

        for(let i = 0; i < messageToDecode.length; i++){
            let newText = String.fromCodePoint(messageToDecode[i].charCodeAt(0)-1);
            newMessage += newText;
        }

        decodeTextBox.value = newMessage;
        decodeButton.disabled = true;
    }

}
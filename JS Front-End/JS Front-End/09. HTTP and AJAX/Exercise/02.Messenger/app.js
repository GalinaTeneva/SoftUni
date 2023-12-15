function attachEvents() {
    const [nameInput, contentInput, sendBtn, refreshBtn] = document.getElementsByTagName("input");
    const messagesTextArea = document.getElementById("messages");

    sendBtn.addEventListener("click", sendMessage);
    refreshBtn.addEventListener("click", getMessages);

    async function sendMessage() {
        const messageFormat = {
            author: nameInput.value,
            content: contentInput.value
        };

        let isValidMessage = nameInput.value !== "" && contentInput.value !== "";

        if (isValidMessage) {
            await fetch("http://localhost:3030/jsonstore/messenger", {
                method: "POST",
                body: JSON.stringify(messageFormat)
            });
        }

        nameInput.value = "";
        contentInput.value = "";
    }

    async function getMessages () {
        const response = await fetch("http://localhost:3030/jsonstore/messenger");
        const messages = await response.json();
        const allMessages = [];

        for (const message of Object.values(messages)) {
            allMessages.push(`${message.author}: ${message.content}`);
        }
        messagesTextArea.textContent = allMessages.join("\n");
    }
}

attachEvents();
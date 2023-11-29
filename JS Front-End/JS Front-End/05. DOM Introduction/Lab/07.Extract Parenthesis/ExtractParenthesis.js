function extract(content) {
    let text = document.getElementById(content).textContent;
    const pattern = /\((.+?)\)/g;

    let result = text.match(pattern);
    return result.join('; ');
}
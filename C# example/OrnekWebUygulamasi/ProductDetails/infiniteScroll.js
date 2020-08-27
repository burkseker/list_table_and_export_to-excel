async function addImageToDOM() {
    const imageDiv = document.createElement('div');
    imageDiv.className = 'one-fourth';

    const imgElement = document.createElement('iframe');
    imgElement.src = generateImageLinks();
    imgElement.height = "1000px"
    imgElement.width = "400px"

    imageDiv.append(imgElement);
    document.querySelector('.container').append(imageDiv);
}

function generateImageLinks() {
    return `https://localhost:44311/WebForm7.aspx`;
}

window.addEventListener('scroll', function () {
    if (window.scrollY + window.innerHeight + 100 >= document.documentElement.scrollHeight) {
        addImageToDOM();
    }
})
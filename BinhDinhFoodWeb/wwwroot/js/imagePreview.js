
var imageInput = document.getElementById("upload-btn");
imageInput.onchange = e => {
    const [file] = imageInput.files;
    if (file) {
        var imgPreview = document.getElementById("img-preview");
        imgPreview.src = URL.createObjectURL(file);
    }
}

var clearBtn = document.getElementById("clear-btn");
clearBtn.onclick = e => {
    var imageInput = document.getElementById("upload-btn");
    var imagePreview = document.getElementById("img-preview");
    imageInput.files = new DataTransfer().files;
    imagePreview.src = "";
}
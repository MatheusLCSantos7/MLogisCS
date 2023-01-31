var settingsMenu = document.querySelector(".settings-menu");
var darkBtn = document.getElementById("dark-btn");

function settingsMenuTogle(){
    settingsMenu.classList.toggle("settings-menu-height");
}

darkBtn.onclick = function(){
    darkBtn.classList.toggle("dark-btn-on")
    document.body.classList.toggle("dark-theme")

    if(localStorage.getItem("theme") == "light"){
        localStorage.setItem("theme","dark")
    }else{
        localStorage.setItem("theme","light")
    }
}

if(localStorage.getItem("theme") == "light"){
    darkBtn.classList.remove("dark-btn-on")
    document.body.classList.remove("dark-theme")
} else if(localStorage.getItem("theme") == "dark"){
    darkBtn.classList.add("dark-btn-on")
    document.body.classList.add("dark-theme")
} else{
    localStorage.setItem("theme","light")
}

const $post = document.querySelector('form')
console.log($post)

$post.addEventListener('submit', function criaPostContrller(infosEvento){
    infosEvento.preventDefault();
    console.log("Estamos criando")
    const $campoCriaPost = document.querySelector('textarea[id=Publisher]') 
    const $listaDePost = document.querySelector('.post-container')

    console.log($listaDePost)
    //alert($campoCriaPost.value)
});
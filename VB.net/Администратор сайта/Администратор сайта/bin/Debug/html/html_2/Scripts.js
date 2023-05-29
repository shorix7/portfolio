function informationURL(introducedURL){
    withoutProtokol = introducedURL.slice((introducedURL.indexOf("//"))+2)
   let protokol = introducedURL.slice(0,introducedURL.indexOf(":"))
   let domen = withoutProtokol.slice(0,withoutProtokol.indexOf("/"))
   let direct = withoutProtokol.slice((withoutProtokol.indexOf("/")))
    alert(`Протокол: ${protokol}, Домен: ${domen}, Путь: ${direct}`) 
}
informationURL(prompt("Введите URL для которого хотите узнать подробную информацию: "))
//Använd try-catch eller if för att all kod inte ska krascha om något skulle kracha
function footerPosition(element, scrollHeight, innerHeigt) {
    try {
        const _element = document.querySelector(element)
        const isTallerthanScreen = scrollHeight >= (innerHeigt + _element.scrollHeight)

        _element.classList.toggle('position-fixed', !isTallerthanScreen)
        _element.classList.toggle('position-static', isTallerthanScreen)
    }
    catch { }
}


//Anropar funktionerna
try {
    const toggleBtn = document.querySelector('[data-option="toggle"]')
    toggleBtn.addEventListener('click', function () {
        const element = document.querySelector(toggleBtn.getAttribute('data-target'))

        if (!element.classList.contains('open-menu')) {
            element.classList.add('open-menu')
            toggleBtn.classList.add('btn-outline-dark')
            toggleBtn.classList.add('btn-toggle-white')
        }

        else {
            element.classList.remove('open-menu')
            toggleBtn.classList.remove('btn-outline-dark')
            toggleBtn.classList.remove('btn-toggle-white')
        }
    })
} catch { }
footerPosition('footer', document.body.scrollHeight, window.innerHeight)



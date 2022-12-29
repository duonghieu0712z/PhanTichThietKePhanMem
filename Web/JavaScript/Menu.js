const menuSwitchBtn = document.getElementById('menu-switch'),
    userMenu = document.getElementById('user-menu'),
    adminMenu = document.getElementById('admin-menu')

const adminLocal = 'Admin'

var isAdmin = localStorage.getItem(adminLocal)

window.onload = () => {
    setMenu(isAdmin)
}

menuSwitchBtn.onclick = () => {
    menuSwitchBtn.innerText === 'User' ? setMenu('isAdmin') : setMenu()
}

function setMenu(state = '') {
    if (state) {
        userMenu.classList.remove('show')
        adminMenu.classList.add('show')
        menuSwitchBtn.innerText = 'Admin'
        console.log(state);
    }
    else {
        userMenu.classList.add('show')
        adminMenu.classList.remove('show')
        menuSwitchBtn.innerText = 'User'
        console.log('Xoa admin');
    }
    localStorage.setItem(adminLocal, state)
}
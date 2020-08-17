const uriAccess = 'access';
let accesses = [];

function getAccesses() {
    setTimeout(function () {
    fetch(uriAccess, {
        method: 'GET'
    }).then(response => response.json())
        .then(data => _displayAccesses(data))
            .catch(error => console.error('Unable to get items.', error));
        getAccesses();
    }, 1000);
}
function _displayAccesses(data) {

    const access_content = document.getElementById('access_finded');
    access_content.innerHTML = '';

    //_displayCount(data.length);

    //const button = document.createElement('button');

    data.forEach(access => {

        let accessdiv = document.createElement('div');

        let accessdivuser = document.createElement('div');
        accessdivuser.style.backgroundImage = "linear-gradient(to left, #0094f0, #0071b8)";
        accessdivuser.style.borderRadius = "border-radius: 0px 0px 70px 0px";

        let userimage = document.createElement('img');
        userimage.setAttribute('src', 'eu.jpg');

        let userfullname = document.createElement('h1');
        userfullname.innerText = access.device.user.fullName;

        let username = document.createElement('p');
        username.innerText = access.device.user.userName;

        accessdivuser.appendChild(userimage);
        accessdivuser.appendChild(userfullname);
        accessdivuser.appendChild(username);

        let accessdivinfo = document.createElement('div');

        let userrule = document.createElement('h3');
        userrule.innerText = access.device.user.rule.type;

        let entry = document.createElement('p');
        entry.innerText = "Entry at " + access.entry;

        let exit = document.createElement('p');
        exit.style.backgroundImage = access.exit == "Waiting" ? "linear-gradient(to left, #f0ac00, #b88a00)" : "linear-gradient(to left, #0cf000, #03b800)";        
        exit.style.borderRadius = " 0px 0px 60px 10px";
        exit.style.transition = "2s";
        exit.innerText = access.exit == "Waiting" ? access.exit : "Exit at " + access.exit;

        accessdivinfo.appendChild(userrule);
        accessdivinfo.appendChild(entry);
        accessdivinfo.appendChild(exit);

        accessdiv.appendChild(accessdivuser);
        accessdiv.appendChild(accessdivinfo);
        access_content.appendChild(accessdiv);

    });

    accesses = data;

}



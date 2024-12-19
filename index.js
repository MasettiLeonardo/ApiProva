const apiBaseUrl = 'https://localhost:7212';

// funzione per visualizzare tutti gli utenti
document.querySelector('#user-btn').addEventListener('click', async () => {
    try {
        const resp = await fetch(`${apiBaseUrl}/api/User/all`, { method: 'GET' });

        if (!resp.ok)
            throw new Error('Error fetching users');

        displayUsers(await resp.json());
    } catch (err) {
        console.error('Errore durante il caricamento degli utenti:', err);
    }
});

// funzione per visualizzare gli utenti
const displayUsers = (users) => {
    const userList = document.querySelector("#user-list");

    userList.innerHTML = ''; // svuota il contenuto precedente

    users.forEach(user => {
        const userDiv = document.createElement('div');
        userDiv.className = 'user';
        userDiv.textContent = `${user.name} ${user.surname} (${user.email})`;
        userList.appendChild(userDiv);
    });
};

// gestione del form per aggiungere un nuovo utente
document.querySelector('#add-user-form').addEventListener('submit', async (event) => {
    event.preventDefault();

    const form = document.querySelector('#add-user-form');
    const formData = new FormData(form);

    const user = {
        name: formData.get('name'),
        surname: formData.get('surname'),
        email: formData.get('email')
    };

    try {
        const response = await fetch(`${apiBaseUrl}/api/User`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });

        if (!response.ok)
            throw new Error('Error adding user');

        alert('User added successfully');

        form.reset();
        document.querySelector('#user-btn').click();

    } catch (error) {
        console.error('Errore durante l\'aggiunta dell\'utente:', error);
    }
});

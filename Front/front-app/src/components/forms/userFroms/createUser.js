export const createUser = async (userData) => {
    try {
        const response = await fetch('/api/User', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(userData),
        });

        if (response.ok) {
            return await response.json();
        } else {
            throw new Error('Erro ao criar usuário');
        }
    } catch (error) {
        throw new Error('Erro na requisição: ' + error.message);
    }
}
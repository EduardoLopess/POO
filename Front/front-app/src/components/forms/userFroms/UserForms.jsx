import React, { useState } from 'react';
import { createUser } from '../userFroms/createUser';
import './UserForms.css'; // Importando o arquivo CSS

const UserForms = () => {
    const [formData, setFormData] = useState({
        name: '',
        surname: '',
        phoneNumber: '',
        cpf: '',
        birthdateString: '',
        gender: '',
        street: '',
        houseNumber: '',
        neighborhood: '',
        complement: '',
        zipCode: '',
        city: '',
        email: '',
        passwordHash: ''
    });

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            
            const formDataWithAccess = {
                ...formData,
        
                profileAccess: 1 // Defina o perfil de acesso como necessário (1, 2, etc.)
            };
            console.log("Dados enviados:", formDataWithAccess);
            const response = await createUser(formDataWithAccess);
            console.log("Usuário criado", response);
            // Lógica adicional após a criação do usuário, se necessário
        } catch (error) {
            console.error('Erro ao criar usuário', error);
            // Tratamento de erros
        }
    };

    const handleChange = (e) => {
        
        setFormData({
            ...formData,
            [e.target.id]: e.target.value
        });
    };

    const handleGenderChange = (e) => {
        const selectedValue = parseInt(e.target.value); // Converte o valor para número inteiro
        let genderValue;
    
        // Mapeia o valor numérico para o enum Gender correspondente
        if (selectedValue === 0) {
            genderValue = 'Male';
        } else if (selectedValue === 1) {
            genderValue = 'Female';
        } else if (selectedValue === 2) {
            genderValue = 'Other';
        }
    
        setFormData({
            ...formData,
            gender: genderValue // Atualiza o estado do campo de gênero com o membro correspondente ao valor selecionado
        });
    };
    


    return (
        <div className="custom-register-container">
            <div className='custom-container'>
                <div className='custom-form'>
                    <div className='custom-form-header'>
                        <h1>Informações Pessoais</h1>
                    </div>
                    <div className='custom-input-group'>
                        <div className='custom-input-box'>
                            <label htmlFor="name">Nome: </label>
                            <input type="text" id="name" placeholder="Digite seu nome" 
                            value={formData.name} onChange={handleChange}
                            />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="surname">Sobrenome: </label>
                            <input type="text" id="surname" placeholder="Digite seu sobrenome" 
                            value={formData.surname} onChange={handleChange}
                            />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="phoneNumber">Telefone: </label>
                            <input type="text" id="phoneNumber" placeholder="Digite seu telefone" 
                            value={formData.phoneNumber} onChange={handleChange}
                            />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="cpf">CPF: </label>
                            <input type="text" id="cpf" placeholder="Digite seu CPF" 
                            value={formData.cpf} onChange={handleChange}
                            />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="date">Data de Nascimento:</label>
                            <input type="date" id="birthdateString" name="birthdate"
                            value={formData.birthdateString} onChange={handleChange}
                            />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="gender">Gênero: </label>
                            <select id="gender" value={formData.gender} onChange={handleGenderChange}>
                                <option value="">Selecione...</option>
                                <option value="0">Masculino</option>
                                <option value="1">Feminino</option>
                                <option value="2">Outro</option>
                            </select>
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="email">Seu e-mail: </label>
                            <input type="text" id="email" placeholder="Digite seu e-mail" 
                            value={formData.email} onChange={handleChange}
                            />
                        </div>
                    </div>
                </div>

                <div className='custom-form'>
                    <div className='custom-form-header'>
                        <h1>Informações de Endereço</h1>
                    </div>
                    <div className='custom-input-group'>
                        <div className='custom-input-box'>
                            <label htmlFor="street">Rua: </label>
                            <input type="text" id="street" placeholder="Digite sua rua" 
                            value={formData.street} onChange={handleChange}
                            />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="houseNumber">Número: </label>
                            <input type="text" id="houseNumber" placeholder="Digite o número" 
                            value={formData.houseNumber} onChange={handleChange}
                            />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="neighborhood">Bairro: </label>
                            <input type="text" id="neighborhood" placeholder="Digite seu bairro" 
                            value={formData.neighborhood} onChange={handleChange}
                            />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="complement">Complemento: </label>
                            <input type="text" id="complement" placeholder="Digite o complemento" 
                            value={formData.complement} onChange={handleChange}
                            />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="zipCode">CEP: </label>
                            <input type="text" id="zipCode" placeholder="Digite seu CEP" 
                            value={formData.zipCode} onChange={handleChange}
                            />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="city">Cidade: </label>
                            <input type="text" id="city" placeholder="Digite sua cidade" 
                            value={formData.city} onChange={handleChange}
                            />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="password">Sua senha: </label>
                            <input type="text" id="passwordHash" placeholder="Digite sua senha" 
                            value={formData.passwordHash} onChange={handleChange}
                            />
                        </div>
                    </div>
                    
                </div>
                
                
            </div>
            <div className='custom-cadastro-button'>
                <button onClick={handleSubmit}>Enviar</button>
            </div>
        </div>
    );
};

export default UserForms;

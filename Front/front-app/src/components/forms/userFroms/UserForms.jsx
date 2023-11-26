import React from 'react';
import './UserForms.css'; // Importando o arquivo CSS

const UserForms = () => {
    return (
        <div className="custom-register-container">
            <div className='custom-container'>
                <div className='custom-form'>
                    <div className='custom-form-header'>
                        <h1>Informações Pessoais</h1>
                    </div>
                    <div className='custom-input-group'>
                        <div className='custom-input-box'>
                            <label htmlFor="Name">Nome: </label>
                            <input type="text" id="Name" placeholder="Digite seu nome" />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="Surname">Sobrenome: </label>
                            <input type="text" id="Surname" placeholder="Digite seu sobrenome" />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="PhoneNumber">Telefone: </label>
                            <input type="text" id="PhoneNumber" placeholder="Digite seu telefone" />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="CPF">CPF: </label>
                            <input type="text" id="CPF" placeholder="Digite seu CPF" />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="birthdate">Data de Nascimento:</label>
                            <input type="date" id="birthdate" name="birthdate"/>
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="Gender">Gênero: </label>
                            <select id="Gender">
                                <option value="">Selecione...</option>
                                <option value="Male">Masculino</option>
                                <option value="Female">Feminino</option>
                                <option value="Other">Outro</option>
                            </select>
                        </div>
                    </div>
                </div>

                <div className='custom-form'>
                    <div className='custom-form-header'>
                        <h1>Informações de Endereço</h1>
                    </div>
                    <div className='custom-input-group'>
                        <div className='custom-input-box'>
                            <label htmlFor="Street">Rua: </label>
                            <input type="text" id="Street" placeholder="Digite sua rua" />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="HouseNumber">Número: </label>
                            <input type="text" id="HouseNumber" placeholder="Digite o número" />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="Neighborhood">Bairro: </label>
                            <input type="text" id="Neighborhood" placeholder="Digite seu bairro" />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="Complement">Complemento: </label>
                            <input type="text" id="Complement" placeholder="Digite o complemento" />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="ZipCode">CEP: </label>
                            <input type="text" id="ZipCode" placeholder="Digite seu CEP" />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="City">Cidade: </label>
                            <input type="text" id="City" placeholder="Digite sua cidade" />
                        </div>
                    </div>
                    
                </div>
                
            </div>
            <div className='custom-cadastro-button'>
                <button>Enviar</button>
            </div>
        </div>
    );
};

export default UserForms;

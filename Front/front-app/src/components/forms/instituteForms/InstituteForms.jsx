import React, { useState } from 'react';
import { createInstitute_api } from '../instituteForms/createInstitute_api'
const InstituteForms = () => {

    const [formData, setFormData] = useState({
        name: '',
        description: '',
        phoneNumber: '',
        site: '',
        CNPJ: '',
        street: '',
        houseNumber: '',
        neighborhood: '',
        complement: '',
        zipCode: '',
        city: '',
        passwordHash: '',
        email: '',
        type: '' 
    });

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const formDataWithAccess = {
                ...formData,
                profileAccess: 2 // Defina o perfil de acesso como necessário (1, 2, etc.)
            };
            const response = await createInstitute_api(formDataWithAccess);
            console.log("Instituto criado", response);
            // Lógica adicional após a criação do usuário, se necessário
        } catch (error) {
            console.error('Erro ao criar Instituto', error);
            // Tratamento de erros
        }
    };

    const handleChange = (event) => {
        const { id, value } = event.target;
        setFormData({ ...formData, [id]: value });
    };

    const handleTypeChange = (event) => {
        const { value } = event.target;
        setFormData({ ...formData, type: value });
    };



    return (
        <div className="custom-register-container">
            <div className='custom-container'>
                <div className='custom-form'>
                    <div className='custom-form-header'>
                        <h1>Informações sobre o Instituto</h1>
                    </div>
                    <div className='custom-input-group'>
                        <div className='custom-input-box'>
                            <label htmlFor="name">Nome: </label>
                            <input type="text" id="name" placeholder="Digite o nome"
                                value={formData.name} onChange={handleChange}
                            />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="description">Descrição do instituto: </label>
                            <textarea type="text" id="description" placeholder=">Digite a descrição do instituto"
                                value={formData.description} onChange={handleChange}
                            />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="phoneNumber">Telefone: </label>
                            <input type="text" id="phoneNumber" placeholder="Digite o telefone de contato"
                                value={formData.phoneNumber} onChange={handleChange}
                            />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="site">Site ou página do instituto: </label>
                            <input type="text" id="site" placeholder="Informe a URL"
                                value={formData.site} onChange={handleChange}
                            />
                        </div>

                        <div className='custom-input-box'>
                            <label htmlFor="CNPJ">CNPJ: </label>
                            <input type="text" id="CNPJ" placeholder="Digite o CNPJ"
                                value={formData.CNPJ} onChange={handleChange}
                            />
                        </div>
                        
                        <div className='custom-input-box'>
                            <label htmlFor="gender">Tipo do instituto: </label>
                            <select id="type" value={formData.type} onChange={handleTypeChange}>
                                <option value="">Selecione...</option>
                                <option value="School">Escola</option>
                                <option value="University">Universidade</option>
                                <option value="Hospital">Hospital</option>
                                <option value="NGO">ONG</option>
                                <option value="Government">Governo</option>
                                <option value="Religious">Religioso</option>
                                <option value="Cultural">Cultural</option>
                                <option value="Sports">Esportivo</option>
                                <option value="Other">Outro</option>
                            </select>
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="email">Seu e-mail: </label>
                            <input type="text" id="email" placeholder="Digite seu e-mail para login"
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
                            <input type="text" id="street" placeholder="Digite a rua"
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
                            <input type="text" id="neighborhood" placeholder="Digite o bairro"
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
                            <input type="text" id="zipCode" placeholder="Digite o CEP"
                                value={formData.zipCode} onChange={handleChange}
                            />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="city">Cidade: </label>
                            <input type="text" id="city" placeholder="Digite a cidade"
                                value={formData.city} onChange={handleChange}
                            />
                        </div>
                        <div className='custom-input-box'>
                            <label htmlFor="password">Sua senha: </label>
                            <input type="text" id="passwordHash" placeholder="Digite sua senha de acesso"
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
}
export default InstituteForms
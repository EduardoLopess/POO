import '../login/Login.css';
import LogoLogin from '../../../assets/LOGO.svg';

const Login = () => {
    return (
        <div className="login-container">
            <div className='container'>
                <div className='form-image'>
                    <img src={LogoLogin} alt="Logo de Login" />
                </div>
                <div className='form'>
                    <div className='form-header'>
                        <h1>Bem Vindo(a)</h1>
                       
                    </div>
                    <div className='input-group'>
                        <div className='input-box'>
                            <label htmlFor="email">E-mail: </label>
                            <input type="text" id="email" placeholder="Digite seu e-mail" />
                        </div>
                        <div className='input-box'>
                            <label htmlFor="password">Senha: </label>
                            <input type="password" id="password" placeholder="Digite sua senha" />
                        </div>
                    </div>
                    <div className='login-button'>
                        <button><a href="#">Entrar</a></button>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Login;
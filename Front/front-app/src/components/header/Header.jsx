import '../header/Header.css'
import { Link , useLocation  } from "react-router-dom";

const Header = () => {
    const path = require('../../assets/logo.png')
    const location = useLocation();
   
    return(
        <header>
            <div className='logo'>
                <img src={path} alt="Logo do site" />
                <p>Mão Solidária</p>
                <p>Junto somos mais fortes.</p>
            </div>
            <ul class="list-menu">
                <li className={`item ${location.pathname === '/' ? 'active' :  '' }`}>
                    <Link to="/" disabled={location.pathname === '/'}>Pagina Inicial</Link>
                </li>
                <li className="item">
                    <Link to="sobre">Sobre</Link>
                </li>

                <li className="item"> 
                    <Link to="contato">Contato</Link>
                </li>
                

                <li className={`item ${location.pathname === '/entrar' ? 'active' : ''}`}>
                    <Link to="/entrar" disabled={location.pathname === '/entrar'}>Entrar</Link>
                </li>

                <li className={`item ${location.pathname === '/cadastro' ? 'active' : ''}`}>
                    <Link to="/cadastro" disabled={location.pathname === '/cadastro'}>Cadastrar-se</Link>
                </li>
            </ul>
        </header>
    );
}

export default Header
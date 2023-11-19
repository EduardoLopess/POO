import { Link , useLocation  } from "react-router-dom";
import '../navbar/Navbar.css'

const Navbar = () => {
    const path = require('../../assets/logo.png');
    const location = useLocation();
    return(
        <nav className="navbar">
            <div className="logo">
                <img src={path} alt="Logo do site"/>
                <p>Mão Solidária</p>
                <p>Junto somos mais fortes.</p>
            </div>
           <ul className="list">
                <li className={`item ${location.pathname === '/' ? 'active' : ''}`}>
                    <Link to="/" disabled={location.pathname === '/'}>Pagina inicial</Link>
                </li>
                <li className="item">
                    <Link to="sobre">Sobre</Link>
                </li>
                <li className="item"> 
                    <Link to="contato">Contato</Link>
                </li>
                <li className="item">
                    <Link>Entrar</Link>
                </li>
                <li className={`item ${location.pathname === '/cadastro' ? 'active' : ''}`}>
                    <Link to="/cadastro" disabled={location.pathname === '/cadastro'}>Cadastrar-se</Link>
                </li>
           </ul>
        </nav>

    );
}
export default Navbar
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css';
import Home from './pages/Home/Home';
import LoginPage from './pages/login/LoginPage';
import Register from './pages/register/Register';
import DonationPage from './pages/donation/DonationPage';




function App() {
  return (
   <BrowserRouter>
    <Routes>
        <Route path='/' element= {<Home/>}/>
        <Route path='/entrar' element = {<LoginPage/>}/>
        <Route path='/cadastro' element = {<Register/>}/>
        <Route path='/doacao' element = {<DonationPage/>}/>
    </Routes>
    
   </BrowserRouter>
  
  );
}

export default App;

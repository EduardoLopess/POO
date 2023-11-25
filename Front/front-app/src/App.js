import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css';
import Home from './pages/Home/Home';
import LoginPage from './pages/login/LoginPage';
import Register from './pages/register/Register';




function App() {
  return (
   <BrowserRouter>
    <Routes>
        <Route path='/' element= {<Home/>}/>
        <Route path='/entrar' element = {<LoginPage/>}/>
        <Route path='/cadastro' element = {<Register/>}/>
    </Routes>
    
   </BrowserRouter>
  
  );
}

export default App;

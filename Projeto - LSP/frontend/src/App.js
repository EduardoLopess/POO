import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Home from './pages/home/Home';
import Sobre from './pages/sobre/Sobre'
import Cadastro from './pages/Cadastro/Cadastro';


function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={ <Home /> } />
        <Route path='/sobre' element = { <Sobre/> } />
        <Route path='/cadastro' element = { <Cadastro/> } />
        
      </Routes>
    </BrowserRouter>
  );
}

export default App;

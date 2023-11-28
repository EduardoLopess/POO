import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css';
import Home from './pages/Home/Home';
import LoginPage from './pages/login/LoginPage';
import Register from './pages/register/Register';
import CampaignDonationPage from './pages/campaingDonationPage/CampaingDonationPage';
import CampaignDonationDetailsPage from './pages/campaingDonationPage/datailsPage/CampaignDonationDetailsPage';
import VolunteeringPage from './pages/volunteeringPage/VolunteeringPage'




function App() {
  return (
   <BrowserRouter>
    <Routes>

      <Route path='/' element= {<Home/>}/>
      <Route path='/entrar' element = {<LoginPage/>}/>
      <Route path='/cadastro' element = {<Register/>}/>
      <Route path='/capanhas-de-doacao' element = {<CampaignDonationPage/>}/>
      <Route path='/campanha-detalhes' element = {<CampaignDonationDetailsPage/>}/>
      <Route path='/voluntaraido' element = {<VolunteeringPage/>}/>
        
    </Routes>
    
   </BrowserRouter>
  
  );
}

export default App;

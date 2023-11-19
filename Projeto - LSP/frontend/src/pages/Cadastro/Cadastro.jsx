import '../Cadastro/Cadastro.css'
import Navbar from "../../components/navbar/Navbar"
import FormsOption from '../../components/Fomulario/forms_option/FormsOption';
import Footer from '../../components/footer/Footer';

const Cadastro = () =>{
   return(

    <>
        <Navbar/>
        <div className='cadastro-container'>
          
            <FormsOption/>
            
       </div>

       <Footer/>
    </>

   );
}

export default Cadastro
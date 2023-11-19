import '../forms_option/FormsOption.css'
import userSvg from '../../../assets/user.svg'
import userSvg2 from '../../../assets/instituto.svg'



const FormsOption = () => {
   
    
    return(
        <div className='container-forms'>
            <div className='conteudo'>
                <img src={userSvg} alt="user"/>
                <hr/>
                <div className='description-conteudo'>
                    <h2>Cadastra-se como Usuario</h2>
                    <p>Ao se cadastrar como usuário, você terá a oportunidade de realizar doações às instituições, caso a opção esteja disponível. Além disso, será possível se inscrever em trabalhos voluntários oferecidos pelas instituições parceiras.</p>
                    <button className='button-cadastro-opt'>CADASTRO</button>
                </div>  
            </div>

            <div className='conteudo'>
                <img src={userSvg} alt="user"/>
                <hr/>
                <div className='description-conteudo'>
                    <h2>Cadastra-se como Instituto</h2>
                    <p>Ao se cadastrar como usuário, você terá a oportunidade de realizar doações às instituições, caso a opção esteja disponível. Além disso, será possível se inscrever em trabalhos voluntários oferecidos pelas instituições parceiras.</p>
                    <button className='button-cadastro-opt'>CADASTRO</button>
                </div>
                 
            </div>  
  

        </div>
       
    );
}

export default FormsOption
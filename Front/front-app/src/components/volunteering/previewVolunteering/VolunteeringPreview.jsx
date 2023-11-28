import { Button } from "react-bootstrap";
import { Link } from 'react-router-dom';
import '../previewVolunteering/VolunteeringPreview.css'


const VolunteeringPreview = () => {
    return (
        <>  
            <div className="volunteeringPreview-container">
                    <div className="title-volunteering">
                        <h2>TITULO DO VOLUNTARIADO</h2>
                    </div>
                    <div className="description-volunteering"> 
                    <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Magni ullam in recusandae reiciendis, tempora dolore voluptates qui explicabo beatae rerum. Rem architecto corrupti aspernatur, mollitia quo blanditiis laboriosam asperiores impedit.</p>  
                    </div>                  
                    <div className="tipe-volunteering">
                        <h2>TIPO: TESTE</h2>
                    </div>
                    
                    <div className="btn-volunterring-container">
                        <Link to="/voluntaraido-detalhes">
                            <Button className="saibaMais-btn-Volunterring">Saber Mais</Button>
                        </Link>
                    </div>
                </div>
     
            
        </>
    );
}
export default VolunteeringPreview
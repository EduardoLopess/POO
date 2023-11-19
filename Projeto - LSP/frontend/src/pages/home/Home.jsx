import Navbar from "../../components/navbar/Navbar";
import Notificacao from "../../components/notificacao/Notificacao";
import '../home/Home.css'

const Home = () => {
    const path_a = require('../../assets/doacao.png');
    const path_b = require('../../assets/voluntariado.png');
    
    return(
        <>
            <Navbar/>
            <Notificacao/>
            <div className="container-home">
                <div className="card-conteudo">
                    <img src={path_a} alt="Doação"/>
                    <h1>Doação</h1>
                    <div className="descrisao">
                        <p>Explore diversas campanhas de doação em andamento na sua região. Descubra como você pode fazer a diferença contribuindo com recursos financeiros, doando itens essenciais ou participando de eventos beneficentes. Além disso, encontre locais de coleta de materiais próximos a você. </p>
                        <p>Seja parte ativa da comunidade, ajudando a fornecer os recursos necessários para causas importantes e impactar positivamente a vida das pessoas ao seu redor.</p>
                    </div>
                    <button>Explorar doações</button>
                </div>
                <div className="card-conteudo">
                    <img src={path_b} alt="Voluntariado"/>
                    <h1>Voluntariado</h1>
                    <div className="descrisao">
                        <p>Descubra uma ampla gama de oportunidades de voluntariado em sua região. Seja parte ativa de causas significativas, oferecendo seu tempo, habilidades e paixão para fazer a diferença na comunidade.</p>
                        <p>Explore oportunidades que se alinhem aos seus interesses e valores. Envolva-se em projetos que impactam positivamente a sociedade, desde atividades sociais e ambientais até programas educacionais e de saúde.</p>
                    </div>
                    <button>Explorar voluntariado</button>
                </div>

            </div>
        </>

    );
}

export default Home
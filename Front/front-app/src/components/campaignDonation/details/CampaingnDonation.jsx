const CampaignDonation = () => {
    return (
        <div className="container-campaign">
            <h1>Título da Campanha</h1>
            <div className="container-description-campaign">
                <p>
                    Descrição detalhada da campanha de doação. Explique o propósito, quem será beneficiado, como as doações serão utilizadas e qual impacto elas terão.
                </p>
                <p>
                    Data de início e término da campanha, se houver. Destaque a urgência da necessidade, se aplicável.
                </p>
                <p>
                    Informações de contato para doações ou para mais detalhes sobre a campanha (e-mail, telefone, site).
                </p>
            </div>
            <div className="container-local-campaign">
                <p>Rua Teste</p>
                <p>Cidade</p>
                <p>Bairro</p>
                {/* Você também pode incluir um mapa ou coordenadas geográficas, se relevante */}
            </div>
            <h3>Materiais Necessários</h3>
            <ul>
                <li>Item 1</li>
                <li>Item 2</li>
                <li>Item 3</li>
                {/* Liste os materiais específicos necessários para a campanha */}
            </ul>
            <p>
                Informações sobre a forma como as doações podem ser feitas: se é possível doar financeiramente, doar itens físicos, voluntariar-se ou participar de eventos relacionados à campanha.
            </p>
        </div>
    );
}
export default CampaignDonation
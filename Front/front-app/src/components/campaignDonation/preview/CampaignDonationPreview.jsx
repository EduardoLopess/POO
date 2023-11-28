import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

import './CampaignDonationPreview.css'; // Arquivo CSS

const CampaignDonationPreview = () => {
    const [campaigns, setCampaigns] = useState([]);

    useEffect(() => {
        fetch('/db.json') 
            .then(response => response.json())
            .then(data => {
                console.log(data); 
                setCampaigns(data.campanhas); 
            })
            .catch(error => console.error('Erro: ', error));
    }, []);
    
    
    return (
        <>   
            {campaigns.map(campaign => (
                <div key={campaign.id} className='campaignPreview-container'>
                    <h2>{campaign.titulo}</h2>
                    <p>{campaign.descricao}</p>
                    <Link to={`/campanha-detalhes/${campaign.id}`}>
                        <button className="saibaMais-btn">Saber Mais</button>
                    </Link>
                </div>
            ))}
        </>
    );
}

export default CampaignDonationPreview;

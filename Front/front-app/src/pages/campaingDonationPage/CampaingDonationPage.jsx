import CampaignDonationPreview from "../../components/campaignDonation/preview/CampaignDonationPreview";
import Header from "../../components/header/Header";

const CampaignDonationPage = () =>  {
    return(
       <>
        <Header/>
        <div className="campaign-page-container">
            <CampaignDonationPreview/>
        </div>
       
       </>
    );

}
export default CampaignDonationPage
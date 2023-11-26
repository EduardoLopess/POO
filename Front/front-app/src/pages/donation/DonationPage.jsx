import CardDonationPreview from '../../components/cardDonation/preview/CardDonationPreview';
import Header from '../../components/header/Header';
import '../donation/DonationPage.css'

const DonationPage = () => {
    return (
        <>
            <Header/>
            <div className='doationPage-container'>
                <CardDonationPreview/>
            </div>
        </>
       
    );
}
export default DonationPage
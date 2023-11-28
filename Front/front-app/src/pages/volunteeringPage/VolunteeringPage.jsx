import Header from '../../components/header/Header'
import VolunteeringPreview from '../../components/volunteering/previewVolunteering/VolunteeringPreview'
import '../volunteeringPage/VolunteeringPage.css'

const VolunteeringPage = () => {
    return (
        <>
            <Header/>
            <div class="volunteeringPage-container">
                <VolunteeringPreview/>
                <VolunteeringPreview/>
                <VolunteeringPreview/>
                <VolunteeringPreview/>
                
                <VolunteeringPreview/>
                <VolunteeringPreview/>
                <VolunteeringPreview/>
                
            </div> 
        </>
    );
}
export default VolunteeringPage
let localTracks = null;
async function connectToRoom(token, roomName, containerId)
{
    localTracks = await Twilio.Video.createLocalTracks({audio: true, video: true});
    const videoTrack = localTracks.find(track => track.kind === 'video');
    if (videoTrack){
        addTrackToDOM(videoTrack, containerId);
    }
    activeRoom = await Twilio.Video.connect(token, {
        name : roomName,
        tracks: localTracks
    });

    activeRoom.participants.forEach(participant => {
        attachParticipantTracks(participant, containerId);
    });

    activeRoom.on('participantConnected', participant => {
        console.log('Participant Connected: ${participant.identity');
        attachParticipantTracks(participant, containerId);
    });
    activeRoom.on('participantDisconnected', participant => {
        console.log('Participant Disconnected: ${participant.identity');
        attachParticipantTracks(participant, containerId);
    });
    activeRoom.on('disconnected', () => {
        console.log('You have left the room');
        detachAllTracks(containerId);
    });
}
function attachParticipantTracks(participant, containerId){
    participant.tracks.forEach(publication => {
        if (publication.isSubscribed) {
            addTrackToDOM(publication.track, containerId);
        }
    });

    participant.on('trackSubscribed', track => {
        addTrackToDOM(track, containerId);
    });

    participant.on('trackUnsubscribed', track => {
        track.detach().forEach(element => element.remove());
    });
}
function addTrackToDOM(track, containerId){
    const container = document.getElementById(containerId);
    if (!container)
    {
        console.error('Container with ID ${containerId} not found');
        return;
    }

    const trackElement = track.attach();
    container.appendChild(trackElement);
    console.log('Appended track element:', trackElement);
}

window.twilioVideo ={
    connectToRoom
}
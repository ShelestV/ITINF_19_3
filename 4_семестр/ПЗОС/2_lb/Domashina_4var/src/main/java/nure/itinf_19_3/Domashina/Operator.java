package nure.itinf_19_3.Domashina;

public class Operator {
    private Status status;
    private Client talkClient;

    public Operator() {
        status = Status.Wait;
    }

    public boolean isFree() {
        return status == Status.Wait;
    }

    public void talkWithClient(Client client) {
        talkClient = client;
        status = Status.Talk;
    }

    public void endCall() {
        talkClient = null;
        status = Status.Wait;
    }

    public boolean isTalkingWith(Client compareClient) {
        if (talkClient == null || compareClient == null) {
            return false;
        }

        return talkClient.equals(compareClient);
    }
}

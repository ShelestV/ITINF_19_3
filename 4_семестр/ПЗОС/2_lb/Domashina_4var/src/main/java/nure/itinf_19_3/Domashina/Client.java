package nure.itinf_19_3.Domashina;

public class Client implements Runnable {
    private Status status;
    private final String name;
    private final CallCenter callCenter;

    public Client(String name, CallCenter callCenter) {
        this.name = name;
        this.callCenter = callCenter;
        status = Status.Wait;
    }

    public void run() {
        int callsBeforeKill = 3;
        for (int call = 0; call < callsBeforeKill; ) {
            if (this.isWaiting()) {
                System.out.println(this.name + " try to contact");

                boolean isSuccessTry = tryContactWithCallCenter();
                if (isSuccessTry) {
                    System.out.println(this.name + " successfully contact with operator");

                    this.talkWithOperator();
                    ++call;
                    this.endOfCall();
                    System.out.println(this.name + " end call");
                } else {
                    System.out.println(this.name + " cannot contact with operator (all operators is busy)");
                }
                this.waitForOperator();
            }
        }
        System.out.println(this.name + " end contract with call center(");
    }

    private boolean isWaiting() {
        return status == Status.Wait;
    }

    private boolean tryContactWithCallCenter() {
        synchronized (callCenter) {
            return callCenter.tryContactClientWithOperatorIfOneFree(this);
        }
    }

    public void talkWithOperator() {
        status = Status.Talk;
        talkOrWait();
    }

    public void endOfCall() {
        callCenter.endOfCallIfClientTalking(this);
        status = Status.Wait;
    }

    public void waitForOperator() {
        status = Status.Wait;
        talkOrWait();

    }
    private void talkOrWait() {
        int sleepTime = 500;
        try {
            Thread.sleep(sleepTime);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }

    @Override
    public int hashCode() {
        return super.hashCode();
    }

    @Override
    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }

        return obj != null &&
                this.getClass() != obj.getClass() &&
                this.name.equals(((Client)obj).name);
    }
}

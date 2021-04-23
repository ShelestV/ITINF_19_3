package nure.itinf_19_3.Domashina;

import java.util.List;

public class CallCenter {
    private final List<Operator> operators;

    public CallCenter(List<Operator> operators) {
        this.operators = operators;
    }

    public boolean tryContactClientWithOperatorIfOneFree(Client client) {
        if (client == null) {
            return false;
        }

        Operator operator = freeOperatorOrNull();
        if (operator != null) {
            operator.talkWithClient(client);
            client.talkWithOperator();

            return true;
        }
        return false;
    }

    private Operator freeOperatorOrNull() {
        for (var operator : operators) {
            if (operator.isFree()) {
                return operator;
            }
        }
        return null;
    }

    public void endOfCallIfClientTalking(Client client) {
        if (client != null) {
            var operator = operatorTalkedWithThisClientOrNull(client);
            if (operator != null) {
                operator.endCall();
            }
        }
    }

    public Operator operatorTalkedWithThisClientOrNull(Client client) {
        for (var operator : operators) {
            if (operator.isTalkingWith(client)) {
                return operator;
            }
        }
        return null;
    }
}

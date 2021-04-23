package nure.itinf_19_3.Domashina;

import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        List<Operator> operators = new ArrayList<>();
        operators.add(new Operator());
        operators.add(new Operator());
        operators.add(new Operator());

        CallCenter callCenter = new CallCenter(operators);

        List<Client> clients = new ArrayList<>();
        clients.add(new Client("Masha", callCenter));
        clients.add(new Client("Katya", callCenter));
        clients.add(new Client("Vova", callCenter));
        clients.add(new Client("Sonya", callCenter));
        clients.add(new Client("Oleg", callCenter));

        for (var client : clients) {
            Thread thread = new Thread(client);
            thread.start();
        }
    }
}

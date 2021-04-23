package nure.itinf_19_3.shelest;

import javax.swing.JFrame;
import javax.swing.JPanel;
import java.awt.Graphics;
import java.awt.BorderLayout;
import java.awt.Color;

public class GUI {
    private final JFrame frame;

    private int degree;
    private final int radius;

    public GUI() throws Exception {
        frame = new JFrame("3 lab");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        DrawPanel panel = new DrawPanel();

        frame.getContentPane().add(BorderLayout.CENTER, panel);

        frame.setVisible(true);
        frame.setResizable(false);
        frame.setSize(400, 400);
        frame.setLocation(300, 300);

        degree = 0;
        radius = 200;

        this.repaint();
    }

    class DrawPanel extends JPanel {
        public void paintComponent(Graphics g) {
            g.setColor(Color.WHITE);
            g.fillRect(0, 0, this.getWidth(), this.getHeight());
            g.setColor(Color.BLUE);
            g.drawLine(
                    radius,
                    radius,
                    getRadiusX(degree),
                    getRadiusY(degree)
            );
            g.setColor(Color.RED);
            g.drawLine(
                    radius,
                    radius,
                    getRadiusX(360 - degree),
                    getRadiusY(360 - degree)
            );
        }
    }

    private int getRadiusX(int degree) {
        if (degree <= 90) {
            return (int) Math.round(radius + radius * Math.sin(degree));
        }
        if (degree <= 180) {
            return (int) Math.round(radius + radius * Math.cos(degree % 90));
        }
        if (degree <= 270) {
            return (int) Math.round(radius - radius * Math.sin(degree % 90));
        }
        return (int) Math.round(radius - radius * Math.cos(degree % 90));
    }

    private int getRadiusY(int degree) {
        if (degree <= 90) {
            return (int) Math.round(radius - radius * Math.cos(degree));
        }
        if (degree <= 180) {
            return (int) Math.round(radius + radius * Math.sin(degree % 90));
        }
        if (degree <= 270) {
            return (int) Math.round(radius + radius * Math.cos(degree % 90));
        }
        return (int) Math.round(radius - radius * Math.sin(degree % 90));
    }

    private void repaint() throws Exception{
        while (true) {
            ++degree;
            frame.repaint();
            try {
                Thread.sleep(50);
            }
            catch (Exception e) {
                throw new Exception();
            }
        }
    }
}

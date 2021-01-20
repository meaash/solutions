package balkezesek;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class BalkezesekMain {

    public static List<Balkezesek> BalkezesekList = new ArrayList<>();

    public static void main(String[] args) {
        loadFromFile();
        //3. feladat
        System.out.println("3. feladat: " + BalkezesekList.size());

        //4.feladat
        System.out.println("4.feladat: ");
        for (Balkezesek item: BalkezesekList) {
            if(item.getLastPlay().contains("1999-10")){
               double heightInCm = item.getHeight() * 2.54;
                System.out.println("\t" + item.getName() + ": " + String.format("%.1f", heightInCm) +"cm");
            }
        }

        //5.feladat
        System.out.println("5. feladat: ");
        System.out.println("Kérem adjon meg egy évszámot 1900 és 1999 között: ");
        boolean isValidYear = false;
        Scanner scanner = new Scanner(System.in);
        int year = scanner.nextInt();
        while (!isValidYear)
        {
            if (year <= 1990 || year >= 1999) {
                System.out.println("Hibás adat kérek egy 1900 és 1999 közötti évszámot: ");
                year = scanner.nextInt();
            }
            else {
                isValidYear = true;
            }
        }
        //6.feladat
        double sum = 0.0;
        int count = 0;
        for (Balkezesek item: BalkezesekList) {
            int firstYear = Integer.parseInt(item.getFirstPlay().substring(0,4));
            int lastYear = Integer.parseInt(item.getLastPlay().substring(0,4));
            if (year >= firstYear && year <= lastYear)
            {
                count++;
                sum += item.getWeight();

            }
        }
        System.out.println("6. feladat: " + String.format("%.2f", sum/count) + " font");

    }

    //2. feladat
    public static void loadFromFile(){
        try (Scanner scanner = new Scanner(BalkezesekMain.class.getResourceAsStream("/balkezesek/balkezesek.csv"))) {
            String firstRow = scanner.nextLine();
            while(scanner.hasNextLine()) {
                String line = scanner.nextLine();
                String[] split = line.split(";|(\r\n)");
                BalkezesekList.add(new Balkezesek(split[0],split[1],split[2],Integer.parseInt(split[3]),Integer.parseInt(split[4])) );
            }
        }
    }
}

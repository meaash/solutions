package nobel;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class NobelMain {

    public static List<Nobel> NobelList = new ArrayList<>();

    public static void main(String[] args) {
        loadFromFile();

        //3.feladat
        for (Nobel n : NobelList) {
            if (n.getKeresztnev().equals("Arthur B.")) {
                System.out.println("3. feladat: " + n.getTipus());
            }
        }
        //4.feladat
        for (Nobel n : NobelList) {
            if (n.getEvszam() == 2017 && n.getTipus().equals("irodalmi")) {
                System.out.println("4. feladat: " + n.getKeresztnev() + " " + n.getVezeteknev());
            }
        }
        //5.feladat
        System.out.println("5. feladat:");
        for (Nobel n : NobelList) {
                if (n.getVezeteknev().equals("") && n.getEvszam() >= 1990) {
                    System.out.println("\t" + n.getEvszam() + ": " + n.getKeresztnev());
                }
        }

        //6.feladat
        System.out.println("6. feladat:");
        for (Nobel n : NobelList) {
            if (n.getVezeteknev().contains("Curie"))
            {
                System.out.println("\t" + n.getEvszam() + ": " + n.getKeresztnev()+ " " + n.getVezeteknev() + "(" + n.getTipus() + ")");
            }
        }
        //7.feladat

        List<String> tipusList = new ArrayList<>();
        for (Nobel n : NobelList) {
            if (!tipusList.contains(n.getTipus()))
            {
                tipusList.add(n.getTipus());
            }
        }

        System.out.println("7. feladat");
        for (String t: tipusList) {
            int db = 0;
            for (Nobel n : NobelList) {
                if (t.equals(n.getTipus()) )
                {
                    db++;
                }
            }
            System.out.println("\t\t" +String.format("%-16s", t) + "\t\t" + db + "db");
        }

        //8.feladat
        NobelList = NobelList.stream().sorted(Comparator.comparingInt(Nobel::getEvszam)).collect(Collectors.toList());
        StringBuilder sb = new StringBuilder();
        for (Nobel n : NobelList) {
            if (n.getTipus().equals("orvosi")){
                sb.append( n.getEvszam() + ": "+ n.getKeresztnev() + " " + n.getVezeteknev()+"\n");
            }
        }

        try {
            Path file = Path.of("orvosi.txt");
            Files.writeString(file, sb);
        }
        catch (IOException ioe) {
            throw new IllegalStateException("Can not write file", ioe);
        }
        System.out.println("8. feladat: orvosi.txt");

    }

        //2. feladat
        public static void loadFromFile () {
            try (Scanner scanner = new Scanner(NobelMain.class.getResourceAsStream("/nobel/nobel.csv"))) {
                String firstRow = scanner.nextLine();
                while (scanner.hasNextLine()) {
                    String line = scanner.nextLine();
                    String[] split = line.split(";|(\r\n)");
                    if (split.length == 4) {
                        NobelList.add(new Nobel(Integer.parseInt(split[0]), split[1], split[2], split[3]));
                    } else {
                        NobelList.add(new Nobel(Integer.parseInt(split[0]), split[1], split[2], ""));
                    }
                }
            }
        }

}

import subprocess
import json
import sys
import os

#list all directories in the current directory
monoServices = subprocess.run("ls -d Services/*", shell=True, stdout=subprocess.PIPE)
monoServices = monoServices.stdout.decode('utf-8').splitlines()
#remove specific keyword from monoServices items
monoServices = [x.replace('Services/', '') for x in monoServices]
#print(monoServices)

changedFolders = subprocess.run('git diff main HEAD --name-only', shell=True, stdout=subprocess.PIPE)

#subproccess out to a list of strings
changedFolders = changedFolders.stdout.decode('utf-8').splitlines()
#remove duplicates
changedFolders = list(dict.fromkeys(changedFolders))

#conver changedFolders items to os.path.dirname 
changedFolders = [os.path.dirname(x) for x in changedFolders]

changedServices = []
#check what monoService item substring are in the changedFolders list
for monoService in monoServices:
    for changedFolder in changedFolders:
        if monoService in changedFolder:
            #replace . with - in monoService
            image = monoService.replace('.', '-').lower()
            x = {"build_folder": "Services/"+monoService, "unitTest_folder": "Tests/Unit/"+monoService, "acceptanceTest_folder": "Tests/Acceptance/"+monoService,"image_name": image}
            #check if x already exist in changedServices
            if x not in changedServices:
                changedServices.append(x)

changedServices = [{"build_folder": "Services/GearsMonoRepoSample.Finance.Web.Api", "unitTest_folder": "Tests/Unit/GearsMonoRepoSample.Finance.Web.Api", "acceptanceTest_folder": "Tests/Acceptance/GearsMonoRepoSam
ple.Finance.Web.Api", "image_name": "gearsmonoreposample-finance-web-api"}, {"build_folder": "Services/GearsMonoRepoSample.Manfucaturing.Web.Api", "unitTest_folder": "Tests/Unit/GearsMonoRepoSam
ple.Manfucaturing.Web.Api", "acceptanceTest_folder": "Tests/Acceptance/GearsMonoRepoSample.Manfucaturing.Web.Api", "image_name": "gearsmonoreposample-manfucaturing-web-api"}, {"build_folder": "S
ervices/GearsMonoRepoSample.SupplyChain.Web.Api", "unitTest_folder": "Tests/Unit/GearsMonoRepoSample.SupplyChain.Web.Api", "acceptanceTest_folder": "Tests/Acceptance/GearsMonoRepoSample.SupplyCh
ain.Web.Api", "image_name": "gearsmonoreposample-supplychain-web-api"}]

json.dump(changedServices, sys.stdout)

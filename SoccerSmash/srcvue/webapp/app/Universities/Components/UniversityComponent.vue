<template>
 
   <div class="mx-auto w-full container bg-white dark:bg-gray-800 dark:bg-gray-800 shadow rounded">
     <div class="w-full flex flex-row justify-between items-center py-5 mt-16">
         <button type="button" class="modal-open ml-5 focus:outline-none text-white text-sm py-2.5 px-5 h-1/2 border-b-4 border-green-600 rounded-md bg-green-500 hover:bg-green-400" @click="newTeam">New</button>
       <h1 class="leading-1 text-5xl text-right mr-10  ">Universidades</h1>
     </div>
     <div class="w-full">
       <table class="min-w-full bg-white dark:bg-gray-800">
         <thead>
         <tr class="w-full h-16 border-gray-300 border-b py-8">
           <!--<th
               class="pl-8 text-gray-600 dark:text-gray-400 font-normal pr-6 text-left text-sm tracking-normal leading-4">
             <input type="checkbox"
                    class="cursor-pointer relative w-5 h-5 border rounded border-gray-400 bg-white dark:bg-gray-800 outline-none"
                    onclick="checkAll(this)" />
           </th>-->
           <th
               class="pl-8 text-gray-600 dark:text-gray-400 font-normal pr-6 text-left text-sm tracking-normal leading-4">
             Id</th>
           <th
               class="text-gray-600 dark:text-gray-400 font-normal pr-6 text-left text-sm tracking-normal leading-4">
             Team's Name</th>
           

           <th
               class="text-gray-600 dark:text-gray-400 font-normal pr-6 text-left text-sm tracking-normal leading-4">
             <div class="opacity-0 w-2 h-2 rounded-full bg-indigo-400"></div>
           </th>
           <td
               class="text-gray-600 dark:text-gray-400 font-normal pr-8 text-left text-sm tracking-normal leading-4">
             More</td>
         </tr>
         </thead>
         <tbody>
         <tr v-for="university in SyncTeamList" v-if="show" class="h-24 border-gray-300 border-b">
           <!--<td
               class="pl-8 pr-6 text-left whitespace-no-wrap text-sm text-gray-800 dark:text-gray-100 tracking-normal leading-4">
             <input type="checkbox"
                    class="cursor-pointer relative w-5 h-5 border rounded border-gray-400 bg-white dark:bg-gray-800 outline-none"
                    onclick="tableInteract(this)" />
           </td>-->
           <td
               class="pl-8 pr-6 text-left whitespace-no-wrap text-sm text-gray-800 dark:text-gray-100 tracking-normal leading-4">{{university.Id}}</td>
           <td
               class="text-sm pr-6 whitespace-no-wrap text-gray-800 dark:text-gray-100 tracking-normal leading-4">
             {{university.Title}}</td>
          
           <td class="pr-6">
             <div class="w-2 h-2 rounded-full bg-indigo-400"></div>
           </td>
           <td class="pr-8 relative">
             <div
                 class="dropdown-content mt-8 absolute left-0 -ml-12 shadow-md z-10 hidden w-32">
               <ul class="bg-white dark:bg-gray-800 shadow rounded py-1">
                 <li
                     @click="editTeam(university.Id)"
                     class="cursor-pointer text-gray-600 dark:text-gray-400 text-sm leading-3 tracking-normal py-3 hover:bg-indigo-700 hover:text-white px-3 font-normal">
                   Edit</li>
                 <li
                     @click="deleteTeam(university.Id)"
                     class="cursor-pointer text-gray-600 dark:text-gray-400 text-sm leading-3 tracking-normal py-3 hover:bg-indigo-700 hover:text-white px-3 font-normal">
                   Delete</li>
               </ul>
             </div>
             <button
                 class="text-gray-500 rounded cursor-pointer border border-transparent focus:outline-none">
               <svg xmlns="http://www.w3.org/2000/svg" onclick="dropdownFunction(this)"
                    class="icon icon-tabler icon-tabler-dots-vertical dropbtn" width="28"
                    height="28" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor"
                    fill="none" stroke-linecap="round" stroke-linejoin="round">
                 <path stroke="none" d="M0 0h24v24H0z" />
                 <circle cx="12" cy="12" r="1" />
                 <circle cx="12" cy="19" r="1" />
                 <circle cx="12" cy="5" r="1" />
               </svg>
             </button>
           </td>
         </tr>
         </tbody>
       </table>
     </div>

     <!--#################################################### MODAL FORM #############################################-->
     <modal-component :show-footer="false">
      <template v-slot:title>
        
      </template> 
       <template v-slot:body>
         <team-form />
       </template>
     </modal-component>
   </div>
  

</template>

<script src="./UniversityComponent.ts">
</script>